import axios from "axios"
import { useEffect } from "react"
import { useState } from "react"

function Persons() {
    const [response,setresponse] = useState([]);
    const getdata = async () => {
        try{
            const res = await axios.get("http://localhost:5097/api/v1/Persons/GetAll");
            setresponse(res.data);
        }
        catch(err)
        {
            console.log("larz");
        }
    }

    useEffect( () =>{
        getdata();
    },[]);

    if(response)
    {
        return (<h1> The person {JSON.stringify(response)} </h1>)
    }
    return (<h1>Hello</h1>)
  }
  
  export default Persons