  var Currency = {
    rates: {"USD":1.0,"EUR":1.12353,"GBP":1.25741,"CAD":0.741035,"ARS":0.0146095,"AUD":0.692716,"BRL":0.197505,"CLP":0.00127282,"CNY":0.140562,"CYP":0.397899,"CZK":0.0422159,"DKK":0.150704,"EEK":0.0706676,"HKD":0.129031,"HUF":0.00325528,"ISK":0.00755043,"INR":0.0132359,"JMD":0.00699741,"JPY":0.00917438,"LVL":1.57329,"LTL":0.320236,"MTL":0.293496,"MXN":0.0460341,"NZD":0.642788,"NOK":0.105787,"PLN":0.254823,"SGD":0.715615,"SKK":21.5517,"SIT":175.439,"ZAR":0.0591271,"KRW":0.000822452,"SEK":0.10763,"CHF":1.04004,"TWD":0.0334865,"UYU":0.0230884,"MYR":0.234867,"BSD":1.0,"CRC":0.00175629,"RON":0.232686,"PHP":0.0199156,"AED":0.272294,"VEB":0.000100125,"IDR":7.09235e-05,"TRY":0.148617,"THB":0.0316776,"TTD":0.148106,"ILS":0.287649,"SYP":0.00194914,"XCD":0.370031,"COP":0.000277262,"RUB":0.0145938,"HRK":0.14841,"KZT":0.00249405,"TZS":0.000431984,"XPT":840.79,"SAR":0.266667,"NIO":0.029648,"LAK":0.000111153,"OMR":2.60078,"AMD":0.00206399,"CDF":0.000544645,"KPW":0.00111102,"SPL":6.0,"KES":0.00941746,"ZWD":0.00276319,"KHR":0.000242792,"MVR":0.0646027,"GTQ":0.13022,"BZD":0.49658,"BYR":4.17929e-05,"LYD":0.714219,"DZD":0.007768,"BIF":0.000524452,"GIP":1.25741,"BOB":0.144991,"XOF":0.00171281,"STD":4.56766e-05,"NGN":0.00257762,"PGK":0.289009,"ERN":0.0666667,"MWK":0.00135895,"CUP":0.0377358,"GMD":0.0194117,"CVE":0.0101889,"BTN":0.0132359,"XAF":0.00171281,"UGX":0.000265315,"MAD":0.103084,"MNT":0.000355537,"LSL":0.0591271,"XAG":17.6542,"TOP":0.442117,"SHP":1.25741,"RSD":0.00955351,"HTG":0.0092294,"MGA":0.000262184,"MZN":0.0144242,"FKP":1.25741,"BWP":0.0845561,"HNL":0.0403252,"PYG":0.0001505,"JEP":1.25741,"EGP":0.0624079,"LBP":0.00066335,"ANG":0.558687,"WST":0.373935,"TVD":0.692716,"GYD":0.00478622,"GGP":1.25741,"NPR":0.00823385,"KMF":0.00228374,"IRR":2.37562e-05,"XPD":1975.8,"SRD":0.134108,"TMM":5.71351e-05,"SZL":0.0591271,"MOP":0.125273,"BMD":1.0,"XPF":0.00941516,"ETB":0.029172,"JOD":1.41044,"MDL":0.0565501,"MRO":0.00263813,"YER":0.00399483,"BAM":0.574451,"AWG":0.558659,"PEN":0.294113,"VEF":0.100125,"SLL":0.00010151,"KYD":1.21951,"AOA":0.00173799,"TND":0.353652,"TJS":0.0975581,"SCR":0.0569079,"LKR":0.00538301,"DJF":0.00562504,"GNF":0.000104535,"VUV":0.00856289,"SDG":0.0180762,"IMP":1.25741,"GEL":0.33157,"FJD":0.460047,"DOP":0.0174133,"XDR":1.37709,"MUR":0.0252008,"MMK":0.000715777,"LRD":0.00503135,"BBD":0.5,"ZMK":5.46588e-05,"XAU":1700.67,"VND":4.28371e-05,"UAH":0.037154,"TMT":0.285676,"IQD":0.000839724,"BGN":0.574451,"KGS":0.0136014,"RWF":0.00106105,"BHD":2.65957,"UZS":9.86352e-05,"PKR":0.00607247,"MKD":0.0181755,"AFN":0.0130291,"NAD":0.0591271,"BDT":0.0117819,"AZN":0.58943,"SOS":0.00173457,"QAR":0.274725,"PAB":1.0,"CUC":1.0,"SVC":0.114286,"SBD":0.121425,"ALL":0.0090359,"BND":0.715615,"KWD":3.24568,"GHS":0.173678,"ZMW":0.0546588,"XBT":9539.01,"NTD":0.0337206,"BYN":0.417929,"CNH":0.140488,"MRU":0.0263813,"STN":0.0456766,"VES":5.08223e-06,"MXV":0.29832},
    convert: function(amount, from, to) {
      return (amount * this.rates[from]) / this.rates[to];
    }
  };