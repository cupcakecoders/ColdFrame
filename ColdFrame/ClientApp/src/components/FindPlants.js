import React, { Component } from 'react';
import PlantPhotocard from "./plant-details/PlantPhotocard";
import { Container, Row, Col, Form, Input, Label, FormGroup, Button } from 'reactstrap';

export default class FindPlants extends Component {
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
        let plantsList = this.state.plants.map(plant => {
            return (
                <Col sm="4" key={plant.id}>
                    <PlantPhotocard plants={plant} />
                </Col>
            )
        })
        return (
            <Container fluid={true}>
                <Row>
                    <Col>
                        <h1>Find Plants</h1><br></br>
                        <h6>This page contains all the plants on our website.</h6>
                        <p> Search below to filter by name </p>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Form>
                            <FormGroup>
                                <Input type="search" name="search" id="search" placeholder="i.e. Tomato" />
                            </FormGroup>
                            <Button>Search</Button>
                        </Form>
                    </Col>
                </Row>
                <br />
                <Row>
                    {plantsList}
                </Row>
            </Container>
        );
    }
}
