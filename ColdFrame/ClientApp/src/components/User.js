import React, { Component } from 'react';
import { Button } from 'reactstrap';
import authService from "./api-authorization/AuthorizeService";


export class Users extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            loading: true,
            error: false
        }
    }
    
    async componentDidMount() {
        const user = await authService.getUser();
        console.log("user", user)
/*        this.setState({
            isAuthenticated,
            userName: user && user.name
        });*/
        fetch(`https://localhost:5001/users/${user.sub}`)
            .then(response => (response.json()))
            .then(userData => {this.setState({users:userData, loading: false});
            })
            .catch(error => {
                console.log(error);
                this.setState({loading: false, error: error});
            })
    }
    
    render (){
        console.log(this.state.users)
        console.log('plantusersprops', this.props.users);
        console.log('auth', authService);
        if (this.state.loading) {
            return <p>Loading...</p>
        }
        if (this.state.error) {
            return <p> There was an error getting user - please try later </p>
        }

        
        return (
            <div>
                <h1>{this.state.users.userName}</h1>
                {this.state.users.plantUsers.map(plant => (
                   <React.Fragment key={plant.plantId}>
                    <p>{plant.plant.plantName}</p>
                    <p>{plant.plant.description}</p>,
                    <img src={`${plant.plant.imageUrl}`}/>
                   </React.Fragment>
                ))}
                <Button href={"https://localhost:5001/plants-page"} color="info">Add more plants</Button>{' '}
            </div>
            
        )
    }
}