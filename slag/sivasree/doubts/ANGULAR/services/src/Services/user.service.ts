import { user } from "src/app/Models/user";

export class userService
{
    users:user[]=[
        new user('siva',23,'male'),
        new user('sree',23,'female'),
        new user('roja',23,'female')
    ];
    GetAllUsers()
    {
        return this.users;
    }

    CreateUser(name:string,age:number,gender:string)
    {
        let newuser=new user(name,age,gender);
        this.users.push(newuser);

    }
}