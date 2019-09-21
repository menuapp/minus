import React, { Component } from "react";
import firebase from "firebase";
import StyledFirebaseAuth from "react-firebaseui/StyledFirebaseAuth";



   firebase.initializeApp({
        apiKey: "AIzaSyDW6MdDf4Vw4Z2O6A5wGYm85hCJ13onZyI",
        authDomain:"altyumlogsig.firebaseapp.com"
    })


export class FirebaseSocial extends Component {
  state = { isSignedIn: false }
  uiConfig = {
    signInFlow: "popup",
    signInOptions: [
      firebase.auth.GoogleAuthProvider.PROVIDER_ID,
      firebase.auth.FacebookAuthProvider.PROVIDER_ID
    ],
    callbacks: {
      signInSuccess: () => false
    }
  }
  

  componentDidMount = ()=>{
    firebase.auth().onAuthStateChanged(user =>{
        this.setState({isSignedIn:!!user})
        console.log("user", user);
    })
  }

  render() {
    return (
        
      <div className="FirebaseSocial"> 
        {this.state.isSignedIn ? (
        <span>  
          <div className="online">●</div>
          <button className="cikis-button" onClick={() => firebase.auth().signOut()}></button>
          <div className="hgpf">
          <h1 className="hosgeldin-text">Hoşgeldiniz "{firebase.auth().currentUser.displayName}"</h1>
          <img alt="profile fotografi" src={firebase.auth().currentUser.photoURL}/>
          </div>
        </span>  
        ) : (
            <StyledFirebaseAuth
                uiConfig={this.uiConfig}
                firebaseAuth={firebase.auth()}
            />
        )}
        <style>{"\
                .cikis-button{\
                 \
                  width: 53px;\
                  height: 54px;\
                  border-radius: 10px;\
                  background-color: aliceblue;\
                  background-image: url(https://cdn4.iconfinder.com/data/icons/cc_mono_icon_set/blacks/48x48/on-off.png);\
                  background-repeat: no-repeat;\
                 \
                }\
                 .hosgeldin-text{\
                  color:#343a40;\
                }\
                 .hgpf{\
                  border-style:solid;\
                }\
                 .online{\
                  color:green;\
                }\
                 \
        "}</style>
      </div>
    );
  }
  
}

export default FirebaseSocial;
