import React, { Component } from 'react';
import { Container, Row, Col, Jumbotron, Button } from 'reactstrap';
import cherry from './cherry.jpg';
import './Home.css';
import authService from "./api-authorization/AuthorizeService";
import {getUserDetails} from "../api";
import Loading from "./Loading";

export class Home extends Component {
  static displayName = Home.name;
    state = {
        userDetails: null,
        loading: true,
        error: false
    }

    async componentDidMount() {
        const user = await authService.getUser();
        try {
            const userDetails = await getUserDetails(user.sub)
            this.setState({userDetails, loading: false});
        } catch (error) {
            this.setState({loading: false, error});
        }
    }

    render () {
        const userDetails = this.state.userDetails;
        if (this.state.loading) {
            return <Loading />
        }
        return (
            <Container style={{minHeight: '100vh'}}>
                <Row>
                    <Col>
                        <div>
                        <Jumbotron style={{ backgroundImage: `url(${cherry})`, backgroundSize: 'cover' }} >
                            <h1 className="display-3">Home grown fruit and veg</h1>
                            <p className="lead">Coldframe is your food growing companion. Choose plants to grow and let us guide you through when to sow and when to harvest. </p>
                            <hr className="my-2" />
                            <p>Use Coldframe on desktop or mobile to keep track of your homegrown produce.</p>
                            <p className="lead">
                                {userDetails ?
                                    <Button href={"my-plants"} color="secondary">View my plants</Button>
                                :
                                    <Button href={"authentication/register"} color="secondary">Sign up</Button>

                                }
                            </p>
                        </Jumbotron>
                        </div>
                    </Col>
                </Row>
             </Container>
        );
  }
}
