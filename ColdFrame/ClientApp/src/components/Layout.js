import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import Moment from 'react-moment';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
          <footer className={'footer'}>
              &copy; <Moment format={'yyyy'}>{Date.now()}</Moment> ColdFrame
          </footer>
      </div>
    );
  }
}
