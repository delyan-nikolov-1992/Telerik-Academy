window.onload = function () {
    function generateTagCloud(stings, minSize, maxSize) {
        var i,
            j,
            k,
            docFragment = document.createDocumentFragment(),
            addedNamesArray = [];

        for (i = 0; i < tags.length; i++) {
            var string = document.createElement('div');
            string.textContent = tags[i];
            string.style.display = 'inline';
            var isAdded = false;

            for (j = 0; j < addedNamesArray.length; j++) {
                if (tags[i] === addedNamesArray[j]) {
                    isAdded = true;
                    break;
                }
            }

            if (!isAdded) {
                var sizer = parseInt(minSize) - 1;

                for (k = 0; k < tags.length; k++) {
                    if (tags[i] === tags[k]) {
                        sizer++;
                    }
                }

                if (sizer > maxSize) {
                    sizer = maxSize;
                }

                console.log(sizer);
                string.style.fontSize = sizer + 'px';
                addedNamesArray.push(tags[i]);
                docFragment.appendChild(string);
            }
        }
        return docFragment;
    }

    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "css",
                "css", "css", "css", "css", "css", "css", "css", "css", "css", "css",
               "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC",
               "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript",
               "http", "http", "CMS", "js", "js", "js", "js", "js", "js", "js", "js"];

    var tagCloud = generateTagCloud(tags, 17, 42);

    var container = document.createElement('div');
    container.style.width = 360 + 'px';
    container.style.height = 100 + 'px';
    container.style.border = '1px solid black';

    container.appendChild(tagCloud);
    document.body.appendChild(container);
};