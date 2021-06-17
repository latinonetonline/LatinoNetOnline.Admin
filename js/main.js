window.clipboardCopy = {
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () {

        })
            .catch(function (error) {
                alert(error);
            });
    }
};



    var newWorker;

    function showUpdateBar() {
        const snackbar = document.getElementById('snackbar');
        snackbar.className = 'show';
    }

    // The click event on the pop up notification
    document.getElementById('reload').addEventListener('click', function () {
        newWorker.postMessage({ action: 'skipWaiting' });
    });

    if ('serviceWorker' in navigator) {

        navigator.serviceWorker.register('/service-worker.js').then(reg => {
            reg.addEventListener('updatefound', () => {
                // A wild service worker has appeared in reg.installing!
                newWorker = reg.installing;

                newWorker.addEventListener('statechange', () => {
                    // Has network.state changed?
                    switch (newWorker.state) {
                        case 'installed':
                            if (navigator.serviceWorker.controller) {
                                // new update available
                                showUpdateBar();
                            }
                            // No update available
                            break;
                    }
                });
            });
        });

        var refreshing;
        navigator.serviceWorker.addEventListener('controllerchange', function () {
            if (refreshing) return;
            window.location.reload();
            refreshing = true;
        });
    }
