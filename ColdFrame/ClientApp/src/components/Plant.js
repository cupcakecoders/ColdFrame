import React, { Component } from 'react';
import Container from "reactstrap/es/Container";
import Row from "reactstrap/es/Row";
import {AddPlantButton} from "./plant-details/PlantButton";

export class Plant extends Component {
    constructor(props) {
        super(props);
        this.state = {
            plants: []
        }
    }
    
    componentDidMount() { 
        
        fetch(`https://localhost:5001/plants/${this.props.match.params.id}`)
            .then(response => response.json())
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }
    
    render() { console.log(this.props)
        return ( 
            <Container fluid={true}>   
                <Row>    
                    <h1>{this.state.plants.plantName}</h1>
                </Row>
                <Row>
                    <img top width="40%" src={this.state.plants.imageUrl} alt="plants" />
                </Row>
                <Row>
                    <p>{this.state.plants.description}</p>
                </Row>
                <Row>
                    <AddPlantButton />
                </Row>
            </Container>
        );
    }
}