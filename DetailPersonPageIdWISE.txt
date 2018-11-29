import React from "react";
import http from "axios";
import { NavLink } from "react-router-dom";
import PersonIndexPage from "./PersonIndexPage";

class DetailsPage extends React.Component {
  state = {
    person: {
      name: "",
      age: "",
      address: ""
    }
  };

  baseUrl = "http://localhost:5000/api/person";
  async componentDidMount() {
    const { params } = this.props.match;
    if (!params || !params.id) {
      this.props.history.goBack();
      return;
    }
    const id = params.id;
    const response = await http.get(`${this.baseUrl}/${id}`);
    if (response.status === 200) {
      const person = response.data;
      this.setState({ person });
    } else {
      this.props.history.goBack();
      return;
    }
  }

  render() {
    const { person } = this.state;
    return (
      <div>
        <div className="d-flex justify-content-end mb-2">
          <NavLink to="/peoples" className="btn btn-info">
            Go back
          </NavLink>
        </div>
        <table className="table table-bordered">
          <tbody>
            <tr>
              <td>Name</td>
              <td>{person.name}</td>
            </tr>
            <tr>
              <td>Age</td>
              <td>{person.age}</td>
            </tr>
            <tr>
              <td>Address</td>
              <td>{person.address}</td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
export default DetailsPage;
