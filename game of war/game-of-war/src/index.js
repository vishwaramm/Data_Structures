import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import War from './War';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<War />, document.getElementById('root'));
registerServiceWorker();
