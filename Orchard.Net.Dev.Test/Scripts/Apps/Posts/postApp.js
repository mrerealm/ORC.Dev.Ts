var postsApp = angular.module('postsApp', ['posts.services']);

postsApp
    .controller('posts.Ctrl', function ($scope, $timeout, Post, User) {

        $scope.lastPost = false;
        $scope.pageIndex = 0;
        $scope.pageSize = 5;
        $scope.displayTimer = false;
        $scope.nofPages = 0;

        $scope.user = {};

        $scope.init = function (id) {
            $scope.user.id = id;
            $scope.loadPosts(id);
            $scope.loadUser(id);
        };

        $scope.loadUser = function (id) {
            $scope.user = User.query({ id: id }); // GET
        };

        $scope.loadPosts = function (id) {
            $scope.posts = Post.query({ id: id }); // GET all
        };

        $scope.addPost = function () { // POST
            $scope.post.$save(function () {
                console.log('added');
            });
        };

        $scope.timerOff = function () {
            $scope.posts = $scope.posts.slice(0, $scope.pageIndex * $scope.pageSize);
            $scope.displayTimer = false;
        };

        $scope.nextPage = function () {
            $scope.loadPosts($scope.user.id );
            $scope.pageIndex = 0;
            $scope.lastPost = false;
        }

        $scope.previousPage = function () {
            $scope.displayTimer = true;
            var data = $scope.posts;
            $scope.nofPages = $scope.pageIndex === 0 ? data.length / $scope.pageSize : $scope.nofPages;
            var page = $scope.pageIndex > 0 ? $scope.pageIndex : $scope.nofPages;
            if (page > 1) page -= 1;
            $scope.pageIndex = page;
            $scope.lastPost = page === 1;
            $timeout(function () { $scope.timerOff();}, 3000);
        }
    });