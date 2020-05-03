import React, { Component } from 'react';
import PlantsDropDown from "./plant-details/PlantsDropdown";
import PlantPhotocard from "./plant-details/PlantPhotocard";
import { Container, Row, Col } from 'reactstrap';

export class PlantsPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            plants: []
        }
    }

    componentDidMount() {
        fetch("https://localhost:5001/plants")
            .then(response => response.json())
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }

render() {
        let plantPhotocard = this.state.plants.map(plant => {
            return (
                <Col sm ="4">
                <PlantPhotocard plants={plant} />
                </Col>
            )
        })
        return (
            <Container fluid>
                <Row>
                    <PlantsDropDown plantsData={this.state.plants}/>
                </Row>
                <Row>
                    {plantPhotocard}
                </Row>
            </Container>
        );
    }
}
