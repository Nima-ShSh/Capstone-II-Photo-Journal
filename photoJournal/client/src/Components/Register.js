import React, { useState, useContext } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";

export default function Register() {
  const navigate = useNavigate();
  const { register } = useContext(UserProfileContext);

  const [fullName, setFullName] = useState();
  const [email, setEmail] = useState();
  const [profileImage, setProfileImage] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
     e.preventDefault();
      if (password && password !== confirmPassword) {
        alert("Passwords don't match. Do better.");
      } else {
        const userProfile = { fullName, email, profileImage };
        debugger;
        register(userProfile, password)
          .then(() => navigate("/"));
      }
   
 };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>
        <FormGroup>
          <Label htmlFor="firstName">Full Name</Label>
          <Input id="firstName" type="text" onChange={e => setFullName(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="lastName">Email</Label>
          <Input id="lastName" type="text" onChange={e => setEmail(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="displayName">Profile Image URL</Label>
          <Input id="displayName" type="text" onChange={e => setProfileImage(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input id="password" type="password" onChange={e => setPassword(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Label for="confirmPassword">Confirm Password</Label>
          <Input id="confirmPassword" type="password" onChange={e => setConfirmPassword(e.target.value)} />
        </FormGroup>
        <FormGroup>
          <Button>Register</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}
