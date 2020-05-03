import React, { Component } from 'react';

export class Plant extends Component {
    constructor(props) {
        super(props);
    }
    
    componentDidMount() { console.log(this.props)
        
        fetch(`https://localhost:5001/plant/${this.props.match.params.id}`)
            .then(response => response.json())
            .then(plantsData => {this.setState({plants: plantsData});
            })
            .catch(error => {console.log(error)}
            )
    }
    
    render() {
        return (
            <div>
            </div>
        );
    }
}