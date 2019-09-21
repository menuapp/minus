const styles = {
	container: {
		width: 'calc(100% - 20px)',
		height: 'calc(100vh - 20px)',
		display: 'flex'
	},
	progressContainer: {
			height: '60px',
			width: "auto",
			marginLeft: "20px",
			marginTop: "20px",
			border: "2px solid #ccc",
			borderRadius: '8px',
			background: 'white',
			fontWeight: 700,
			display: 'flex',
			alignItems: 'center',
			paddingLeft: '15px'
			
	},
	stagesContainer: {
			flex: 1,
			display: 'flex',
			flexDirection: 'column',
			justifyContent: 'center',
			margin: '15px 0px 15px 15px',
			// height: 'calc(100% - 20px)',
			border: "2px solid #ccc",
			borderRadius: '8px',
	},
	stages:{
		display: 'flex',
		flex: 1,
		position: 'relative',
		borderRadius: '8px',
		width: 'calc(100% - 20px)',
		// justifyContent: 'center',
		// alignItems: 'center',
	},
	stageContent: {
		display: 'flex',
		margin: '10px',
		borderRadius: '8px',
		width: 'calc(100%)',
		height: '100%',
		background: '#eee',
		position: "absolute",
		justifyContent: 'center',
		alignItems: 'center',
		fontSize: "40px",
		color: '#a1a1a1',
		fontWeight: 700,
		overflow: 'auto'
	},
	stageButton: {
		display: 'flex',
		justifyContent: 'flex-end',
		height: "40px",
		marginTop: "20px",
		marginRight: "10px",
		marginBottom: '10px'
	},
	circle: {
		marginTop: "20px",
		marginBottom: "20px",
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		color: '#ccc',
		width: '30px',
		height: '30px',
		background:'white',
		borderRadius: '40px',
		border: '3px solid #ccc',
		zIndex: '3',
		position: 'relative'
	},
	circleActive: {
		width: '50px',
		height: '50px',
		border: '3px solid #ccc',
	},
	circleComplete: {
		border: '3px solid #6bada7',
	},
	header: {
		// height: '60px',
		// marginLeft: "20px",
		// marginTop: "20px",
		// border: "2px solid #ccc",
		// borderRadius: '8px',
		// color: '#6bada7',
		// fontWeight: 700,
		// fontSize: '24px',
		// display: 'flex',
		// alignItems: 'center',
		// paddingLeft: '15px'
	},
	footer: {
		height: '30px',
		marginLeft: "20px",
		border: "2px solid #ccc",
		borderRadius: '8px',
		color: '#6bada7',
		fontWeight: 700,
		fontSize: '24px',
		display: 'flex',
		alignItems: 'center',
		paddingLeft: '15px'
	}
}



export default styles
