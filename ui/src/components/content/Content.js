import React from 'react'

function Content({input}) {

    const title = {
        width: '25%',
        backgroundColor: '#fff',
        padding: '5px 15px',
        borderRadius: '15px',
        letterSpacing: '2px',
        textAlign: 'center'
    }

    return (
        <div className="container mt-5">
            <div style={title} className="mb-5">
                {input}
            </div>
        </div>
    )
}

export default Content;