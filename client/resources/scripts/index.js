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

function addPost()
{
    const postApiUrl = "https://localhost:5001/api/posts";
    const postAdd = document.getElementById("text").postText;
    
    fetch(postApiUrl, 
    {
        method: "POST",
        headers: 
        {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(
        {
            text: postAdd
        })
    })
    .then((response)=>
    {
        console.log(response);
        getPosts();
    })
}

function editPost()
{
    const editApiUrl = "https://localhost:5001/api/posts";
    const postEdit = document.getElementById("text").setAttribute('onclick', 'addPost('+text+')');
    
    fetch(editApiUrl, 
    {
        method: "PUT",
        headers: 
        {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(
        {
            text: postEdit
        })
    })
    .then((response)=>
    {
        console.log(response);
        getPosts();
    })
}

function deletePost()
{
    const deleteApiUrl = "https://localhost:5001/api/posts";
    const postDelete = document.getElementById("id").value;
    
    fetch(deleteApiUrl, 
    {
        method: "DELETE",
        headers: 
        {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(
        {
            id: postDelete
        })
    })
    .then((response)=>
    {
        console.log(response);
        getPosts();
    })
}

