$('#btnSave').click(function(){
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    createBlog(title,author,content);
});


function createBlog(title,author,content){
    const blogs = localStorage.getItem("Tbl_Blog");
    let lst =[];
    if(blogs !== null){
        lst=JSON.parse(blogs);
    }
    const blogModel = {
        id:uuidv4(),
        title:title,
        author:author,
        content:content
    };
    lst.push(blogModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("Tbl_Blog",jsonBlog);
    successMessage("Save success");
    clear();
}


function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }

function successMessage(message){
    alert(message);
}

function errorMessage(message){
    alert(message);
}

function clear(){
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}