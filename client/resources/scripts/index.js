function getPosts()
{
    const allPostsApiUrl = "https://localhost:5001/api/posts";

    fetch(allPostsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        let html = "<ul>";
        json.forEach((post)=>{
            html += "<li>" + post.text + "</li>";
            html += "<button onclick=\"editPost("+post.text+")\">Edit</button>";
        });
        html += "</ul>";
        document.getElementById("posts").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}