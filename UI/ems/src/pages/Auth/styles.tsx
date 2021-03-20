import styled from 'styled-components';

export const Title = styled.h1`
    position: absolute;
    font-weight: 500;
    font-size: 100px;
    opacity: 0.75;
    color: white;
    left: 15%;
`

export const Wrapper = styled.div`
    display: grid;
    height: 100vh;
    align-items: center;
    justify-items: center;
`

export const AuthBox = styled.div`
    display: grid;
    grid-template-columns: 1fr;
    grid-template-rows: 1fr 3fr 1fr;
    align-items: center;
    grid-auto-rows: auto;
    width: 40%;
    background-color: black;
    opacity: 0.75;
    border: 3px solid darkgray;
    border-radius: 5px;
    height: 40%;
    h1 {
        margin-top: 2%;
        font-size: 50px;
        font-weight: 300;
        display: grid;
        color: white;
        justify-self: center;
        align-self: flex-start;
    }
    h3 {
        color: white;
        justify-self: center;
    }
`
export const Form = styled.form`
    display: grid;
    grid-template-columns: 1fr;
    height: 100%;
    justify-items: center;
    p {
        width: 50%;
        color: white;
        justify-self: center;
    }
    input {
        height: 40px;
        width: 50%;
        opacity: 1;
        :focus {
            outline: none;
        }
        
    }
    button {
        width: 30%;
        background-color: white;
        height: 50px;
        display: grid;
        align-items: center;
        font-size: 20px;
    }
    h3 {
        a {
            color: white;
            :visited {
                color: white;
            }
        }
    }
`