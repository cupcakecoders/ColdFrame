﻿import React, { Component } from 'react';
import Container from "reactstrap/es/Container";
import Row from "reactstrap/es/Row";
import {AddPlantButton} from "./plant-details/PlantButton";
import authService from "./api-authorization/AuthorizeService";
import {getPlantDetails} from "../api";
import Loading from "./Loading";

export class Plant extends Component {
    state = {
        plantDetails: null,
        user: null,
        loading: true,
        error: false
    }

    async componentDidMount() {
        const user = await authService.getUser();
        try {
            const plantDetails = await getPlantDetails(this.props.match.params.id)
            this.setState({plantDetails, user, loading: false});
        } catch (error) {
            this.setState({loading: false, error});
        }
    }
    
    render() {
        const plant = this.state.plantDetails;
        const user = this.state.user;
        if (this.state.loading) {
            return <Loading />
        }
        return ( 
            <Container fluid={true}>   
                <Row>    
                    <h1>{plant.plantName}</h1>
                </Row>
                <Row>
                    <img width="40%" src={plant.imageUrl} alt="plants" />
                </Row>
                <Row>
                    <p>{plant.description}</p>
                </Row>
                <Row>
                    <AddPlantButton plantId={plant.id} userId={user.sub}/>
                </Row>
            </Container>
        );
    }
}