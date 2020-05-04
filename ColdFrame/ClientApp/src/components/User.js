import React, { Component } from 'react';
import { Button } from 'reactstrap';


export class Users extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            loading: true
        }
    }
    
    componentDidMount() { 
        fetch(`https://localhost:5001/users/${this.props.match.params.id}`)
            .then(response => (response.json()))
            .then(userData => {this.setState({users:userData, loading: false});
            })
            .catch(error => {console.log(error)})
    }
    
    render (){ console.log(this.state.users)
        if (this.state.loading) {
            return <p>Loading...</p>
        }
        console.log('plantusers', this.state.users.plantUsers);
        
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