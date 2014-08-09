define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store = (function () {
        function countTypes() {
            var typesCount = {},
                i,
                type;

            for (i in this._items) {
                type = this._items[i].type;

                if (typesCount[type]) {
                    typesCount[type]++;
                } else {
                    typesCount[type] = 1;
                }
            }

            return typesCount;
        }

        function hasProperty(object, property) {
            var prop;

            for (prop in object) {
                if (prop === property) {
                    return true;
                }
            }

            return false;
        }

        function itemsSortedBy(sortBy, typeArr) {
            var sortedItems = [],
                i,
                len,
                item;

            if (typeArr) {
                for (i = 0, len = this._items.length; i < len; i++) {
                    item = this._items[i];

                    if (typeArr.indexOf(item.type) !== -1) {
                        sortedItems.push(item);
                    }
                }
            } else {
                sortedItems = this._items.slice(0);
            }

            sortedItems.sort(sortBy);

            return sortedItems.slice(0);
        }

        function searchByName(sortBy, partOfName) {
            var sortedItems = [],
                i,
                len,
                item;

            for (i = 0, len = this._items.length; i < len; i++) {
                item = this._items[i];

                if (item.name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1) {
                    sortedItems.push(item);
                }
            }

            sortedItems.sort(sortBy);

            return sortedItems.slice(0);
        }

        function itemsSortedByPrice(minPrice, maxPrice) {
            var sortedItems = [],
                i,
                len,
                item,
                hasMaxPrice = true;

            if (maxPrice === -1) {
                hasMaxPrice = false;
            }

            for (i = 0, len = this._items.length; i < len; i++) {
                item = this._items[i];

                if (item.price > minPrice && ((!hasMaxPrice) || (hasMaxPrice && item.price < maxPrice))) {
                    sortedItems.push(item);
                }
            }

            sortedItems.sort(sortByPrice);

            return sortedItems.slice(0);
        }

        function sortByName(it1, it2) {
            var it1Name = it1.name.toLowerCase(),
                it2Name = it2.name.toLowerCase();

            if (it1Name < it2Name) {
                return -1;
            } else if (it1Name > it2Name) {
                return 1;
            } else {
                return 0;
            }
        }

        function sortByPrice(it1, it2) {
            var it1Price = it1.price,
                it2Price = it2.price;

            return it1Price - it2Price;
        }

        function Store(name) {
            this._name = name;
            this._items = [];
        }

        Object.defineProperty(Store.prototype, '_name', {
            get: function () {
                return this.name;
            },
            set: function (value) {
                if (!value || value.length < 6 || value.length > 30) {
                    throw new Error('The name of the store should be between 6 and 30-characters-long!');
                }

                this.name = value;
            },
            enumerable: true,
            configurable: true
        });

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw new Error('The store can keep in stock only items!');
                }

                this._items.push(item);

                return this;
            },
            getAll: function () {
                return itemsSortedBy.call(this, sortByName);
            },
            getSmartPhones: function () {
                var types = ['smart-phone'];

                return itemsSortedBy.call(this, sortByName, types);
            },
            getMobiles: function () {
                var types = ['smart-phone', 'tablet'];

                return itemsSortedBy.call(this, sortByName, types);
            },
            getComputers: function () {
                var types = ['pc', 'notebook'];

                return itemsSortedBy.call(this, sortByName, types);
            },
            filterItemsByType: function (filterType) {
                var types = [];
                types.push(filterType);

                return itemsSortedBy.call(this, sortByName, types);
            },
            filterItemsByPrice: function (options) {
                var minPrice,
                    maxPrice;

                if (!hasProperty(options, 'min')) {
                    minPrice = 0;
                } else {
                    minPrice = options.min;
                }

                if (!hasProperty(options, 'max')) {
                    maxPrice = -1;
                } else {
                    maxPrice = options.max;
                }

                return itemsSortedByPrice.call(this, minPrice, maxPrice);
            },
            countItemsByType: function () {
                return countTypes.call(this);
            },
            filterItemsByName: function (partOfName) {
                return searchByName.call(this, sortByName, partOfName);
            }
        };

        return Store;
    })();

    return Store;
});