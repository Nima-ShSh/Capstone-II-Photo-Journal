import React, { useContext, useEffect } from "react";
import { PostContext } from "../../providers/JournalPostProvider";
import { JournalPost } from "./JournalPost";

export const JournalPostList = () => {
  const { journalPosts, GetAllJournalPosts } = useContext(PostContext);


  useEffect(() => {
    GetAllJournalPosts();
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          {journalPosts.map((singlePost) => (
            <JournalPost key={singlePost.id} JournalPost={singlePost} />
          ))}

        </div>
      </div>
    </div>
  );
};

