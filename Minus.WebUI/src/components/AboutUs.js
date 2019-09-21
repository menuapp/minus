import React, { Component } from "react";


export class AboutUs extends Component {
  render() {
    return (
      <div className="restoran-hakkinda">
      <br />
      <br />
      <br />
      <br /><br />
      <br /><br />
      <br />
        <p>
          Kalyon Restoran müşterilerine daima en iyi hizmeti ve sunumu
          gerçekleştirmek için 2000 yılından beri değişmeyen tek yerinde tekne
          restoran konseptinde siz değerli müşterilerine devamlı yenilikçi
          zengin menüsü ile hizmet vermeye devam etmektedir.
        </p>
        <p>
          Özenli hizmet, güleryüzlü servis, uygun fiyatlar ve tadına doyulmaz
          bir balık keyfi için Kalyon Balık Restoran, hem kapalı hem açık
          alanlara sahip olmanın avantajıyla dört mevsim boyunca balık
          sevenlerin akınına uğruyor.
        </p>
        <p>
          Birbirinden lezzetli deniz ürünleri, mezeleri, alternatif menüleri,
          doyumsuz deniz manzarası ve huzurlu ortamıyla Kalyon Restoran balık
          keyfini eksiksiz yaşatıyor.
        </p>
        <p>
          İstanbul’lun en güzel Noktalarından biri olan Riva sahillerinde
          sizlere 15 senedir hizmet vermekten mutluk duyuyoruz.
        </p>
        <style>{"\
                .restoran-hakkinda{\
                  font-size: small;\
                  background-color: aliceblue;\
                  font-family: verdana;\
                }\
                 \
                 \
        "}</style>
      </div>
    );
  }
}

export default AboutUs;
