import React, { Component } from 'react';
import styles from '../../styles';
import Button from './Button';
import { StepperContext } from '../../App'


export const Step = ({num, text}) => (
	<StepperContext.Consumer>
		{value => {
			const {stage} = value
			return stage === num ? <div key={num} style={styles.stageContent}>{text}</div> : null 
		}}
	</StepperContext.Consumer>
)

class Steps extends Component {
	render() {
		return (
			<StepperContext.Consumer>
				{(context) => {
					const {stage,handleClick} = context
					return (
						<div style={styles.stagesContainer}>
							<div style={styles.stages}>
									{this.props.children}
							</div>
							<div style={styles.stageButton}>
								<Button disabled={stage === 4 } click={handleClick}>Devam</Button>
							</div>
						</div>
					)
				}}
			</StepperContext.Consumer>
		);
	}
}

export default Steps;
