import { GeoMap } from "../Visualizations";

function Dashboard (){
    return (
        <div className="flex-grow-1 p-4">
      <div className="container-fluid">
        <GeoMap/>

        <div className="row">
          <div className="col-lg-6">
            <h3>Time Series Chart</h3>
          </div>
          <div className="col-lg-6">
            <h3>Bar Chart</h3>
          </div>
        </div>

        <div className="row">
          <div className="col-lg-6">
            <h3>Pie Chart</h3>
          </div>
          <div className="col-lg-6">
            <h3>Bubble Chart</h3>
          </div>
        </div>
      </div>
    </div>
    );
}

export default Dashboard;