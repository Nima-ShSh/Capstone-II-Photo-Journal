import React from "react";
import { Card, CardBody } from "reactstrap";
import { Link } from "react-router-dom";

const User = ({ user }) => {
  return (
    <Card className="m-4">      
      <CardBody>
        <Link to={`/users/${user.id}`}><strong>{user.fullName}</strong></Link>
      <p><b>Display Email:</b> {user.email}</p>
      </CardBody>
    </Card>
  );
};

export default User;