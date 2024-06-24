const TblBlog = "Tbl_Blog";

//createBlog();
// readBlog();
//updateBlog("1c1e2905-88f0-45a7-9964-7571b79e2a50",'fadfdf','fadfdaf','fadfadf');

deleteBlog("1c1e2905-88f0-45a7-9964-7571b79e2a50");
function readBlog(){
    const result = localStorage.getItem(TblBlog);
    console.log(result);
}

function createBlog (){
    const blogs = localStorage.getItem(TblBlog);
    // console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    const reqModel = {
        BlogId:uuidv4(),
        BlogTitle:"Testing",
        BlogAuthor:"Testing",
        BlogContent:"Testing",
     };
     lst.push(reqModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(TblBlog,jsonBlog);
}

function updateBlog(id,title,author,content){
    const blogs = localStorage.getItem(TblBlog);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x=>x.BlogId === id);
    console.log(items);
    console.log(items.lenght);
    if(items.lenght == 0 || items === undefined){
        console.log("No data found.")
        return;
    }
    const item = items[0];
    item.BlogTitle = title;
    item.BlogAuthor=author;
    item.BlogContent = content;

    console.log(item);
    const index = lst.findIndex(x=>x.BlogId ===id);
    console.log(index);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(TblBlog,jsonBlog);
}

function deleteBlog(id){
    const blogs = localStorage.getItem(TblBlog);
    let lst =[];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x=>x.BlogId === id);
    if(items.lenght == 0 || items === undefined){
        console.log("No data found.")
        return;
    }
    lst = lst.filter(x=>x.BlogId !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(TblBlog,jsonBlog);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }