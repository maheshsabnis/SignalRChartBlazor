function marketLineChart([]) {
    let data = [];
    let labels = [];
    // data points for chart range on Y-Axis
    data = arguments[0];
    // labels on X-Axis
    labels = arguments[1];
    var chart1 = c3.generate({
        bindto: '#market',
        data: {
            columns: [
                data
            ]
        },
        axis: {
            x: {
                type: 'category',
                categories: labels,
                label: {
                    text: 'CompanyName',
                    position: 'outer-center'
                }
            },
            y: {
                label: {
                    text: 'Volume',
                    position: 'outer-center'
                }
            }
        }
    });
}

function marketBarChart([]) {
    let data = [];
    let labels = [];
    data = arguments[0];
    labels = arguments[1];
    var chart = c3.generate({
        bindto: '#market',
        data: {
            columns: [
                data
            ],
            type: 'bar'
        },
        bar: {
            width: {
                ratio: 0.5
            }

        },
        axis: {
            x: {
                type: 'category',
                categories: labels,
                label: {
                    text: 'CompanyName',
                    position: 'outer-center'
                }
            },
            y: {
                label: {
                    text: 'Volume',
                    position: 'outer-center'
                }
            }
        }
    });
}
