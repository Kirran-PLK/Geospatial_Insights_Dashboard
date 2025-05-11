

function Sidebar() {
    return (
        <div className="bg-dark text-light p-3" style={{ minHeight: "100vh", width: "250px" }}>
      <h4 className="mb-4">Filters</h4>

      <div className="mb-3">
        <label className="form-label">Category</label>
        <select className="form-select">
          <option value="">All</option>
          <option value="env">Environment</option>
          <option value="tech">Technology</option>
          <option value="health">Healthcare</option>
        </select>
      </div>

      <div className="mb-3">
        <label className="form-label">Year</label>
        <input type="number" className="form-control" placeholder="e.g. 2023" />
      </div>

      <div className="mb-3">
        <label className="form-label">Intensity Range</label>
        <input type="range" className="form-range" min="0" max="100" />
      </div>

      <button className="btn btn-primary w-100">Apply Filters</button>
    </div>
    );
}

export default Sidebar;