import React from 'react';
import http from 'axios';





class AddPersonInfoPage extends React.Component {

  state = {
    name: '',
    age: '',
    address: '' 
  };

  baseUrl = "http://localhost:5000/api/person";

  handleChange = (event) => {
    const { name, value } = event.target;
    this.setState({
      [name]: value
    });
    //console.log(this.state);
  };

  handleSubmit = async (event) => {
    event.preventDefault();
    const {name, age, address}=this.state;
    const response = await http.post(this.baseUrl,{name,age,address});
    if(response.status === 201){

      this.props.history.push('/peoples'); //redirect to another page
       
    }
     
  }; 




  render() {
    return (
      <div className="card-body border">
        <div className="offset-2 col-sm-8">
          <form onSubmit={this.handleSubmit}>
            <div className="form-group row">
              <label htmlFor="name" className="col-sm-2 col-form-label">
                Name
                    </label>
              <div className="col-sm-10">
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  name="name"
                  placeholder=""
                  onChange={this.handleChange}
                />
              </div>
            </div>
            <div className="form-group row">
              <label htmlFor="age" className="col-sm-2 col-form-label">
                Age
                    </label>
              <div className="col-sm-10">
                <input
                  type="number"
                  className="form-control"
                  id="age"
                  name="age"
                  placeholder=""
                  onChange={this.handleChange}

                />
              </div>
            </div>
            <div className="form-group row">
              <label htmlFor="address" className="col-sm-2 col-form-label">
                Address
                    </label>
              <div className="col-sm-10">

                <textarea name="address" id="address" className="form-control" onChange={this.handleChange}></textarea>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-sm-2"></div>
              <div className="col-sm-10">
                <button className="btn  btn-primary" type="submit">Submit</button>
              </div>
            </div>
          </form>
        </div>
      </div>
    );
  }
}
export default AddPersonInfoPage;