import React from 'react';
import { Wrapper, AuthBox, Title, Form } from './styles';


export const Auth: React.FC = () => {
    return (
        <>
            <Title> Evaluation Monitoring System App </Title>
            <Wrapper>
                <AuthBox>
                    <h1> Log in to your account </h1>
                    <Form> 
                        <p> Login </p>
                        <input/>
                        <p> Password </p>
                        <input/>  
                        <button> Log in </button>
                    </Form>
                    <h3> Don't have a account? <a href='#'>Register</a> </h3>
                </AuthBox>
            </Wrapper>
        </>
    )
}