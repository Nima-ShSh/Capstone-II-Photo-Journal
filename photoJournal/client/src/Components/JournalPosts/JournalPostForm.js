import React, {useContext, useEffect, useState} from "react"
import { PostContext } from "../../providers/JournalPostProvider";
// import { useNavigate } from "react-router-dom";
import JournalPost from "./JournalPost";


export const PostForm = () => {
    const {GetAllJournalPosts} = useContext(PostContext)

    const [post, setPost] = useState({
        Title: "",
        ImageLocation: "",
        Content:"",
        UserId: 1
    });
    
    // const navigate = useNavigate();

    useEffect(()=> {
        GetAllJournalPosts()
    }, []);


    const handleControlledInputChange = (event)=> {
        const newPost = {...post}
        newPost[event.target.id] = event.target.value
        
        setPost(newPost)
    }

  

    
    return(
        <form className="postForm">
            <h2>New Post</h2>
            <fieldset>
                <div className="formGroup">
                <label htmlFor="title">Post Title</label>
                <input type="text" id="title" onChange={handleControlledInputChange} 
                        required autoFocus className="form-control" 
                        placeholder="post title" value={JournalPost.title}/>
                </div>
           </fieldset>
        </form>
    )
}
