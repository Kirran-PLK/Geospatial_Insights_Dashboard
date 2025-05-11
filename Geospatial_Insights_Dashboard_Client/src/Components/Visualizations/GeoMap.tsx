import React from "react";
import { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useGetGeoMapDataQuery } from "../../Apis/insightsApi";
import { setGeoMapData } from "../../Storage/Redux/GeoMapSlice";

function GeoMap() {
    const dispatch = useDispatch();
    const {data, isLoading} = useGetGeoMapDataQuery(null);

    useEffect(() => {
  if (!isLoading) {
    console.log("GeoMap data received:", data); // ✅ Log the full data
    dispatch(setGeoMapData(data?.result));
  }
}, [isLoading, data, dispatch]);
     

  if (isLoading) {
    return <div>Loading...</div>;
  }
    return (
        <div className="card mb-4">
      <div className="card-body" style={{ height: "500px" }}>
        {/* Replace with actual map component */}
        <div className="text-center text-muted">[Geo-Map Placeholder]</div>
      </div>
    </div>
    );
}

export default GeoMap;