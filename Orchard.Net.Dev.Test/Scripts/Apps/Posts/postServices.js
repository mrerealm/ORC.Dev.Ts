//I've used this before, but got the idea originally from:
//https://www.sitepoint.com/creating-crud-app-minutes-angulars-resource/

var apiUrl = 'https://jsonplaceholder.typicode.com/'

var services = angular.module('posts.services', ['ngResource']);

services.factory('Post', ['$resource', function ($resource) {
    return $resource(apiUrl + 'posts?userId=:id', { id: '@id' }, {
        query: { method: 'GET', isArray: true },
        save: { method: 'POST' }
    });
}]);

services.factory('User', ['$resource', function ($resource) {
    return $resource(apiUrl + 'users/:id', { id: '@id' }, {
        query: { method: 'GET', isArray: false },
        save: { method: 'POST' }
    });
}]);

