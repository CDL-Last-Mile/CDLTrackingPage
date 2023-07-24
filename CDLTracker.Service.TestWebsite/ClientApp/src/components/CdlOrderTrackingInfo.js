import React, { Component } from 'react';

export class CdlOrderTracking extends Component {
    static displayName = CdlOrderTracking.name;

    constructor(props) {
        super(props);
        this.state = { datasets: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderTable(datasets) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>OrderTrackingId</th>
                        <th>ReferenceNumber</th>
                        <th>ShipmentCreated</th>
                        <th>TrackingEvents</th>
                        <th>DeliveryComplete</th>
                        <th>City</th>
                        <th>State</th>
                        {/*<th>Vpod</th>*/}
                        <th>Exception</th>
                        <th>ExceptionDetails</th>
                        <th>DriverName</th>
                        <th>Lat</th>
                        <th>Long</th>
                        <th>ServerTimestamp</th>
                    </tr>
                </thead>
                <tbody>
                    {datasets.map(dataset =>
                        <tr key={1}>
                            <td>{dataset.orderTrackingId}</td>
                            <td>{dataset.referenceNumber}</td>
                            <td>{dataset.shipmentCreated}</td>
                            <td>{dataset.trackingEvents}</td>
                            <td>{dataset.deliveryComplete}</td>
                            <td>{dataset.city}</td>
                            <td>{dataset.state}</td>
                            {/*<td>{dataset.vpod}</td>*/}
                            <td>{dataset.exception}</td>
                            <td>{dataset.exceptionDetails}</td>
                            <td>{dataset.driverName}</td>
                            <td>{dataset.lat}</td>
                            <td>{dataset.long}</td>
                            <td>{dataset.serverTimestamp}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CdlOrderTracking.renderTable(this.state.datasets);

        return (
            <div>
                <h1 id="tabelLabel" >Order Tracking Info</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    objToQueryString(obj) {
        const keyValuePairs = [];
        for (const key in obj) {
            keyValuePairs.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
        }
        return keyValuePairs.join('&');
    }

    async populateData() {
        const queryString = this.objToQueryString({
            orderTrackingID: '20095.070722',
            isordertrackingid: true,
        });
        const response = await fetch(`https://localhost:44372/api/cdltracker/GetCdlOrderTrackingInfo?${queryString}`);

        const data = await response.json();
        console.log(data);
        this.setState({ datasets: data.result, loading: false });
    }
}
