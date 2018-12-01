requirejs.config({
    baseUrl: "content/scripts",
    paths: {
        "request": "libs/request",
    },
    shim: {

    }
});

requirejs(["index"]);