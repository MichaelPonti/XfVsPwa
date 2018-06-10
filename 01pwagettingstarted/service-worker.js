// service worker
(function() {

	'use strict';

	// our list of cache'd items. We can fill this in more later if we want.
	var filesToCache = [
		'.',
		'index.html',
		'page404.html',
		'pageoffline.html',
		'my.css',
		'my.js',
		'https://code.jquery.com/jquery-3.3.1.slim.min.js',
		'https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js',
		'https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js'
	];

	var staticCacheShell = 'app-shell';

	self.addEventListener('install', function (event) {
		console.log('installing sw and caching statics');
		event.waitUntil(
			caches.open(staticCacheShell)
				.then(function (cache) {
					console.log('adding static shel cache');
					cache.addAll(filesToCache);
					return;
				}).catch(function(error) {
					console.log(error);
				})
		);
	});

	self.addEventListener('fetch', function(event) {
		console.log('fetch event for ', event.request.url);
		event.respondWith(
			caches.match(event.request).then(function(response) {
				if (response) {
					console.log('found ', event.request.url, ' in cache');
					return response;
				}

				console.log('network request for ', event.request.url);
				return fetch(event.request).then(function(response) {
					if (response.status === 404) {
						return caches.match('page404.html');
					}

					return caches.open(staticCacheShell).then(function(cache) {
						if (event.request.url.indexOf('test') < 0) {
							cache.put(event.request.url, response.clone());
						}

						return response;
					});
				});
			}).catch(function(error) {
				console.log('Error ', error);
				return caches.match('pageoffline.html');
			})
		);
	});



})();