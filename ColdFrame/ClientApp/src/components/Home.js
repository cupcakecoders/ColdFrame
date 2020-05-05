import React, { Component } from 'react';
import { Container, Row, Col, Jumbotron, Button } from 'reactstrap';
import cherry from './cherry.jpg';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <Container fluid={true}>
            <div>
            <Row>
                <Col>
                    <div>
                    <Jumbotron style={{ backgroundImage: `url(${cherry})`, backgroundSize: 'cover' }} >
                        <h1 className="display-3">Home grown fruit and veg</h1>
                        <p className="lead">Coldframe is your food growing companion. Choose plants to grow and let us guide you through when to sow and when to harvest. </p>
                        <hr className="my-2" />
                        <p>Use Coldframe on desktop or mobile to keep track of your homegrown produce.</p>
                        <p className="lead">
                            <Button href={"https://localhost:5001/plants-page"} color="secondary">Find plants</Button>
                        </p>
                    </Jumbotron>
                    </div>
                </Col>
            </Row>
            </div>
        </Container>
    );
  }
}
