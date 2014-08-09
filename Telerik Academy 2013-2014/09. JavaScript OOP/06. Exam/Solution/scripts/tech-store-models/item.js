define(function () {
    'use strict';
    var Item = (function () {
        function Item(type, name, price) {
            this._type = type;
            this._name = name;
            this._price = price;
        }

        Object.defineProperty(Item.prototype, '_type', {
            get: function () {
                return this.type;
            },
            set: function (value) {
                if (value !== 'accessory' && value !== 'smart-phone' && value !== 'notebook' &&
                        value !== 'pc' && value !== 'tablet') {
                    throw new Error('The type of the item is invalid!');
                }

                this.type = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Item.prototype, '_name', {
            get: function () {
                return this.name;
            },
            set: function (value) {
                if (!value || value.length < 6 || value.length > 40) {
                    throw new Error('The name of the item should be between 6 and 40-characters-long!');
                }

                this.name = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Item.prototype, '_price', {
            get: function () {
                return this.price;
            },
            set: function (value) {
                if (typeof value !== 'number' || parseFloat(value) !== value || value <= 0) {
                    throw new Error('The price of the item should be a positive decimal floating-point number!');
                }

                this.price = value;
            },
            enumerable: true,
            configurable: true
        });

        return Item;
    })();

    return Item;
});