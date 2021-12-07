//import React, { Component } from 'react';
import React from 'react';
import {
	Link,
	withRouter
} from 'react-router-dom';


//class Navigation extends Component {
//render() {
//function Navigation(props) {
const Navigation = (props) => {
		return (
			<ul>
				<li>
					<Link to="/">Home</Link>
				</li>
				<li>
					<Link to="/comments">Comments Demo</Link>
				</li>
				<li>
					<Link to="/styled-components">Styled Components Demo</Link>
				</li>
				<li>
					<Link to="/react-jss">React-JSS Demo</Link>
				</li>
				<li>
					<Link to="/emotion">Emotion Demo</Link>
				</li>
				<li>
					<Link to="/lazy-load">Lazy loading demo</Link>
				</li>
			</ul>
		);
	}
//}

export default withRouter(Navigation);
