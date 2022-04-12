import React from "react";
import { Card, CardBody } from "reactstrap";
import { Link } from "react-router-dom";

export const JournalPost = ({ JournalPost }) => {

    return (
        <Card className="m-4">
        <CardBody>
        <p> Thread title: <Link to={`/journalposts/${JournalPost.id}`}><strong>{JournalPost.title}</strong> </Link>
        </p>
        <p className="text-left px-0">Posted by: {JournalPost.user.fullName}</p>
        <p className="text-left px-0">Date posted: {new Date(JournalPost.createDateTime).toLocaleDateString('en-us')}</p>
        </CardBody>
      </Card>
    );
};