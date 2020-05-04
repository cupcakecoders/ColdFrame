import React, { Component } from 'react';

export class Users extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: []
        }
    }
    
    componentDidMount() { 
        fetch(`https://localhost:5001/users/${this.props.match.params.id}`)
            .then(response => (response.json()))
            .then(userData => {this.setState({users:userData});
            })
            .catch(error => {console.log(error)})
    }
    
    render (){ console.log(this.state.users)
        //if auth user.username === state.user (.each username) then show username + plants. get by id same as did for plants
        //https://localhost:5001/users/73add300-ea56-473f-a4d9-a88f4ee4f990 
        
        return (
            <div>
                <h1></h1>
            </div>
        )
    }
}