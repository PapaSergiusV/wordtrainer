(this.webpackJsonpfrontend2=this.webpackJsonpfrontend2||[]).push([[0],{258:function(e,t,n){},259:function(e,t,n){"use strict";n.r(t);var c,s,a=n(0),o=n.n(a),i=n(21),r=n.n(i),l=n(134),j=n(135),d=n(151),u=n(147),b=n(106),O=n.n(b),h=n(152),x=n(261),v=n(262),p=n(277),f=n(98),g=n(26),m=n(42),w=n(267),S=n(67),C=n(263),L=n(265),N=n(268),k=n(270),y=n(271);!function(e){e[e.zero=0]="zero",e[e.one=1]="one",e[e.two=2]="two",e[e.three=3]="three",e[e.four=4]="four",e[e.five=5]="five",e[e.All=6]="All",e[e.HighLevel=7]="HighLevel",e[e.LowLevel=8]="LowLevel"}(c||(c={})),function(e){e[e.toRus=0]="toRus",e[e.toEng=1]="toEng",e[e.random=2]="random"}(s||(s={}));var I=n(6),E=[{text:c[c.All],value:c.All},{text:c[c.HighLevel],value:c.HighLevel},{text:c[c.LowLevel],value:c.LowLevel},{text:c[c.five],value:c.five},{text:c[c.four],value:c.four},{text:c[c.three],value:c.three},{text:c[c.two],value:c.two},{text:c[c.one],value:c.one},{text:c[c.zero],value:c.zero}],F=function(e){var t=e.options,n=e.saveOptions,c=Object(a.useState)(t),o=Object(m.a)(c,2),i=o[0],r=o[1],l=Object(a.useState)(!1),j=Object(m.a)(l,2),d=j[0],u=j[1],b=i.scope!==t.scope||i.direction!==t.direction||i.isLearned!==t.isLearned,O=function(){r(t),u(!1)};return Object(I.jsxs)(I.Fragment,{children:[Object(I.jsx)("div",{className:"settingsIconWrapper",onClick:function(){return u(!d)},children:Object(I.jsx)(y.a,{})}),Object(I.jsx)(w.a,{title:"Settings",visible:d,onCancel:O,footer:[Object(I.jsx)(S.a,{type:"primary",onClick:function(){n(i),u(!1)},disabled:!b,children:"Save"},"save"),Object(I.jsx)(S.a,{onClick:O,children:"Cancel"},"cancel")],children:Object(I.jsxs)(I.Fragment,{children:[Object(I.jsx)(C.a.Item,{label:"Scope",children:Object(I.jsx)(L.a,{value:i.scope,onChange:function(e){r(Object(g.a)(Object(g.a)({},i),{},{scope:e}))},disabled:i.isLearned,children:E.map((function(e){return Object(I.jsx)(L.a.Option,{value:e.value,children:e.text},e.value)}))})}),Object(I.jsx)(C.a.Item,{label:"Translation direction",children:Object(I.jsxs)(N.a.Group,{value:i.direction,onChange:function(e){r(Object(g.a)(Object(g.a)({},i),{},{direction:e.target.value}))},children:[Object(I.jsx)(N.a.Button,{value:s.random,children:"random"}),Object(I.jsx)(N.a.Button,{value:s.toRus,children:"to russian"}),Object(I.jsx)(N.a.Button,{value:s.toEng,children:"to foreign"})]})}),Object(I.jsx)(C.a.Item,{children:Object(I.jsx)(k.a,{checked:i.isLearned,onChange:function(e){r(Object(g.a)(Object(g.a)({},i),{},{isLearned:e.target.checked}))},children:"Show only learned words"})})]})})]})},A=n(148),B=n(264),z=n(269),H=n(272),J=n(273),R=n(274),T=n(275),_=n(276),G=n(40),M=n(266),P=function(e){var t=e.progress;return Object(I.jsx)("div",{className:"progress",children:Object(I.jsx)(M.a,{strokeColor:{"0%":"#108ee9","100%":"#87d068"},showInfo:!1,percent:t,status:"active"})})},D=function(e,t){var n=Object(g.a)({},e);return-1===t&&5===n.points?n.points=3:n.points+=t,n.points>5?n.points=5:n.points<0&&(n.points=0),n},W={up:0,down:0,noChange:0},q=function(e){var t=e.words,n=e.openSession,c=e.closeSession,o=e.direction,i=function(){return o===s.random?Math.random()>.5?"rus":"eng":o===s.toEng?"rus":"eng"},r=Object(a.useState)(),l=Object(m.a)(r,2),j=l[0],d=l[1],u=Object(a.useState)([]),b=Object(m.a)(u,2),O=b[0],x=b[1],v=Object(a.useState)(W),p=Object(m.a)(v,2),f=p[0],w=p[1],C=Object(a.useState)(i()),L=Object(m.a)(C,2),N=L[0],k=L[1],y=Object(a.useState)(0),E=Object(m.a)(y,2),F=E[0],M=E[1],q=function(){M(100),d(void 0),x([]),c(O)};Object(a.useEffect)((function(){(null===t||void 0===t?void 0:t.length)?(d(t[0]),w(W),M(0)):t&&(h.a.warning({message:"No words loaded"}),M(0))}),[t]),Object(a.useEffect)((function(){if(t&&O&&j){var e=t.findIndex((function(e){return e.id===(null===j||void 0===j?void 0:j.id)}));e===t.length-1?q():(d(t[e+1]),k(i),M((e+1)/t.length*100))}}),[O]);var K=function(e){t&&j&&(!function(e){switch(e){case 1:return w(Object(g.a)(Object(g.a)({},f),{},{up:f.up+1}));case-1:return w(Object(g.a)(Object(g.a)({},f),{},{down:f.down+1}));case 0:w(Object(g.a)(Object(g.a)({},f),{},{noChange:f.noChange+1}))}}(e),x([].concat(Object(A.a)(O),[D(j,e)])))},Q=Boolean(f.up||f.down||f.noChange);return null===t?Object(I.jsxs)("div",{className:"card card-".concat(Q?"3-lines":"1-line"),children:[Q&&Object(I.jsxs)(I.Fragment,{children:[Object(I.jsx)(P,{progress:F}),Object(I.jsx)("h2",{children:"Session statistic"}),Object(I.jsxs)("div",{className:"stat",children:[Object(I.jsx)("div",{className:"stat-item",children:Object(I.jsx)(B.a,{title:"Successfully repeated",value:f.up,valueStyle:{color:"#3f8600"},prefix:Object(I.jsx)(H.a,{})})}),Object(I.jsx)("div",{className:"stat-item",children:Object(I.jsx)(B.a,{title:"Not changed",value:f.noChange,valueStyle:{color:"#666666"},prefix:Object(I.jsx)(J.a,{})})}),Object(I.jsx)("div",{className:"stat-item",children:Object(I.jsx)(B.a,{title:"Forgotten",value:f.down,valueStyle:{color:"#cf1322"},prefix:Object(I.jsx)(R.a,{})})})]})]}),Object(I.jsx)(S.a,{type:"primary",onClick:n,children:"Start new session"})]}):0===t.length?Object(I.jsxs)("div",{className:"card card-1-line",children:[Object(I.jsx)("div",{children:Object(I.jsx)("p",{children:"No words according to the current settings"})}),Object(I.jsx)(S.a,{onClick:q,children:"Go back"})]}):j?Object(I.jsxs)("div",{className:"card card-3-lines",children:[Object(I.jsx)(P,{progress:F}),Object(I.jsxs)("div",{className:"word-info",children:[Object(I.jsxs)("span",{children:[j.points,"/5"]}),Object(I.jsxs)("div",{className:"direction",children:["rus"===N&&Object(I.jsx)(T.a,{}),Object(I.jsx)("img",{src:"en"===j.language?"/learningApp/en.png":"/learningApp/fr.png",alt:"flag"}),"eng"===N&&Object(I.jsx)(T.a,{})]}),Object(I.jsx)(z.a,{color:j.isLearned?"green":"orange"})]}),Object(I.jsx)("div",{className:"word",onClick:function(){return k("eng"===N?"rus":"eng")},children:j[N]}),Object(I.jsxs)("div",{className:"btns",children:[Object(I.jsx)(S.a,{onClick:function(){return K(-1)},children:Object(I.jsx)(R.a,{})}),Object(I.jsx)(S.a,{onClick:function(){return K(0)},children:Object(I.jsx)(_.a,{})}),Object(I.jsx)(S.a,{onClick:function(){return K(1)},children:Object(I.jsx)(H.a,{})})]})]}):Object(I.jsxs)("div",{className:"card card-1-line",children:[Object(I.jsx)(P,{progress:F}),Object(I.jsx)(G.a,{})]})},K="vocabulary_options",Q=window.localStorage,U=function(e){Q.setItem(K,JSON.stringify(e))},V=function(){var e=Q.getItem(K);return e?JSON.parse(e):null},X=function(e){Object(d.a)(n,e);var t=Object(u.a)(n);function n(e){var a;return Object(l.a)(this,n),(a=t.call(this,e)).loadOptions=function(){var e=V();return e||{scope:c.All,direction:s.random,isLearned:!1}},a.updateOptions=function(e){U(e),a.setState({options:e})},a.openSession=function(){var e=a.state.options,t=e.scope,n=e.isLearned,s="/learning/open_session?".concat(n?"isLearned=true":"scope=".concat(c[t]));O()(s).then((function(e){a.setState({words:e.data.words,loaded:!0})})).catch((function(e){h.a.error({message:"Error",description:e.toString()})}))},a.closeSession=function(e){O.a.post("/learning/close_session",{words:e}).then((function(e){200===e.status&&a.setState({loaded:!1,words:null})})).catch((function(e){h.a.error({message:"Error",description:e.toString()})}))},a.state={showRus:!0,options:a.loadOptions(),words:null,loaded:!1},a}return Object(j.a)(n,[{key:"render",value:function(){var e=this,t=this.openSession,n=this.closeSession,c=this.state,s=c.options,a=c.loaded,o=c.words;return Object(I.jsxs)(I.Fragment,{children:[Object(I.jsxs)("div",{className:"header",children:[Object(I.jsx)("a",{href:"/",children:Object(I.jsx)(p.a,{})}),a&&o?Object(I.jsx)(f.a,{onClick:function(){return n([])}}):Object(I.jsx)(F,{options:s,saveOptions:function(t){return e.updateOptions(t)}})]}),Object(I.jsxs)(x.a,{children:[Object(I.jsx)(v.a,{xs:0,sm:1,md:6}),Object(I.jsx)(v.a,{xs:24,sm:22,md:12,children:Object(I.jsx)(q,{words:o,openSession:t,closeSession:n,direction:s.direction})})]})]})}}]),n}(a.Component),Y=function(e){e&&e instanceof Function&&n.e(3).then(n.bind(null,278)).then((function(t){var n=t.getCLS,c=t.getFID,s=t.getFCP,a=t.getLCP,o=t.getTTFB;n(e),c(e),s(e),a(e),o(e)}))};n(257),n(258);r.a.render(Object(I.jsx)(o.a.StrictMode,{children:Object(I.jsx)(X,{})}),document.getElementById("root")),Y()}},[[259,1,2]]]);
//# sourceMappingURL=main.4605790d.chunk.js.map