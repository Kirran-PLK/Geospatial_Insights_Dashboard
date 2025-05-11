import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const insightsApi = createApi({
    reducerPath: "insightsApi", 
    baseQuery: fetchBaseQuery({
        baseUrl: "https://localhost:7144/api/Insights/",
    }),
    tagTypes: ["Insights"],
    endpoints: (builder) => ({ // fixed typo here
        getGeoMapData: builder.query({
            query: () => ({
                url: "geo-map",
            }),
            providesTags: ["Insights"],
        }),
    }),
});

export const { useGetGeoMapDataQuery } = insightsApi;
export default insightsApi;
