import React from 'react';
import { Header} from '../Components/Layout';
import { Dashboard, Sidebar } from '../Components/Page';

function App() {
  return (
    <div>
      <Header />
      <div className="d-flex">
        <Sidebar/>
        <Dashboard/>
      </div>
    </div>
  );
}

export default App;
