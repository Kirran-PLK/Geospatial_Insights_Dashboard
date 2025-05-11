import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    geoMapData: [],
};

export const GeoMapSlice = createSlice({
    name: "GeoMapData",
    initialState: initialState,
    reducers: {
        setGeoMapData: (state, action) => {
            state.geoMapData = action.payload;
        }
    },   
});

export const { setGeoMapData } = GeoMapSlice.actions;
export const GeoMapReducer = GeoMapSlice.reducer;