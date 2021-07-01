import React, { useState } from "react";
import { Link } from "react-router-dom";
import "../home/Home.css";

function Home() {

    const [input, setInput] = useState("");

    const homeInputButton = {
        width: '500px',
        padding: '7px',
        border: '1px solid #fff',
        borderRadius: '15px',
    }

    const homeContinueButton = {
        width: '500px',
        padding: '7px',
        borderRadius: '15px',
    }

    function handleClick() {
        if(input === '' || input === null) {
            alert("Please enter the input !");
        }
    }

    function handleSubmit(e) {
        e.preventDefault();
    }

    return (
        <div className="container text-center mt-5">
        <div className="home-header text-white mb-3">
            <h1>INTERNSHIP PROJECT</h1>
        </div>
        <div className="home-description text-white mb-5">
            <p>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex molestias
            quidem et pariatur! Aperiam magnam iste accusantium laudantium tempore
            in architecto facere illo facilis eius! Amet exercitationem animi, nam
            veniam necessitatibus rerum omnis atque explicabo officia illum vitae
            in porro nulla laborum quam id quod aperiam hic. Nihil nesciunt
            tenetur laborum reiciendis veritatis, eveniet placeat ipsa sed autem
            eaque! Nesciunt, cupiditate mollitia voluptatem odio eos sit vitae
            animi earum voluptatum deleniti labore velit quisquam, aut vel nisi,
            soluta debitis modi hic tempora facere saepe! Illo dolore veniam
            aliquam ipsa fugiat ducimus maxime aliquid et quod nihil veritatis
            tenetur, necessitatibus velit!
            </p>
        </div>
        <form action="" className="mb-3" onSubmit={handleSubmit}>
            <label htmlFor="">
            <input
                style={homeInputButton}
                type="text"
                value={input}
                name="input"
                onChange={(e) => setInput(e.target.value)}
            />
            </label>
        </form>
        <div className="home-btn">
            <Link to="shopping-list">
                <button 
                    style={homeContinueButton} 
                    className="btn btn-outline-success"
                    onClick={handleClick}
                >
                Continue
                </button>
            </Link>
        </div>
        </div>
    );
}

export default Home;
