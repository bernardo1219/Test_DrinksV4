// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


let favoriteDrinks = []
let viewActual = 'SEARCH'

$(function () {
    getIngredientsData()
    getFavoriteDrinks()

    $("#btn_search_cocktails").click(function () {
        getCocktailsData()
    })

    $("input[name='typeSearch']").change(function () {
        controlTypeSearch()
    })

    $("#btn_favorite_drinks").click(function () {
        controlViewActual()
    })
})

async function getIngredientsData() {
    try {
        const response = await fetch('/cocktail/GetIngredientsCocktails', {
            method: 'GET',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: { 'Content-Type': 'application/json' },
            redirect: 'follow',
            referrerPolicy: 'no-referrer'
        })
        if (response.ok) {
            const dataIngredients = await response.json()
            console.log('All ingredients: ', dataIngredients)

            $("#slIngredients").append("<option value=''>-- Select --</option>");
            for (i = 0; i < dataIngredients.length; i++) {
                $("#slIngredients").append(
                    "<option value='" + dataIngredients[i].strIngredient1 + "'>" +
                    dataIngredients[i].strIngredient1.replace(' ', '_') +
                    "</option>");
            }
            $(".bloqueo_pantalla").hide()
        } else {
            alert("There is an error!")
            $(".bloqueo_pantalla").hide()
        }
    } catch (e) {
        console.error(e)
        alert("There is an error!")
        $(".bloqueo_pantalla").hide()
    }
}

async function getFavoriteDrinks() {
    try {
        const response = await fetch('/cocktail/GetAllFavoriteDrinks', {
            method: 'GET',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: { 'Content-Type': 'application/json' },
            redirect: 'follow',
            referrerPolicy: 'no-referrer'
        })
        if (response.ok) {
            const favoriteDrinksRes = await response.json()
            console.log('All favorite drinks: ', favoriteDrinksRes)
            favoriteDrinks = favoriteDrinksRes
        } else {
            alert("There is an error!")
        }
    } catch (e) {
        console.error(e)
        alert("There is an error!")
    }
}

async function getCocktailsData() {
    const param = $("input[name='typeSearch']:checked").val() === 'BY_NAME' ? $("#txtNameCocktail").val() : $("#slIngredients").val()
    if (param) {
        const showError = () => {
            alert("There is an error!")
            $(".bloqueo_pantalla").hide()
            $("#results_search").html("")
        }
        try {
            $(".bloqueo_pantalla").show()
            const typeSearch = $("input[name='typeSearch']:checked").val()
            const url = `/cocktail/getCocktails?param=${param}&typeSearch=${typeSearch}`

            const response = await fetch(url, {
                method: 'GET',
                mode: 'cors',
                cache: 'no-cache',
                credentials: 'same-origin',
                headers: { 'Content-Type': 'application/json' },
                redirect: 'follow',
                referrerPolicy: 'no-referrer'
            })
            if (response.ok) {
                const cocktails = await response.json()
                console.log('Result search: ', cocktails)

                if (cocktails && cocktails.length > 0) {
                    let rows = ''
                    for (let i = 0; i < cocktails.length; i++) {
                        const disable = favoriteDrinks.find(d => parseInt(d.idDrink) === parseInt(cocktails[i].idDrink)) ? "disabled" : ""
                        let templateCard = `<div class="col-sm mb-4">
                                                    <div class="card" style="width: 18rem;">
                                                        <img src="${cocktails[i].strDrinkThumb}" class="card-img-top">
                                                        <div class="card-body">
                                                            <h5 class="card-title">${cocktails[i].strDrink}</h5>
                                                            <button 
                                                                class="btn btn-primary"
                                                                onclick="saveFavoriteDrink(${cocktails[i].idDrink}, '${cocktails[i].strDrink}', '${cocktails[i].strDrinkThumb}', this)"
                                                                    ${disable}
                                                            >
                                                                    Add favorite
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>`
                        rows += templateCard
                    }
                    $("#results_search").html(`<div class="row">${rows}</div>`)
                } else {
                    $("#results_search").html("<h3>No data found</h3>")
                }
                $(".bloqueo_pantalla").hide()
            } else {
                showError()
            }
        } catch (e) {
            console.error(e)
            showError()
        }
    } else {
        alert('A param is required!')
    }
}

async function saveFavoriteDrink(idDrink, strDrink, strDrinkThumb, element) {
    try {
        $(".bloqueo_pantalla").show()
        const response = await fetch(`/cocktail/setFavoriteDrink?idDrink=${idDrink}`, {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: { 'Content-Type': 'application/json' },
            redirect: 'follow',
            referrerPolicy: 'no-referrer'
        })
        if (response.ok) {
            const result = await response.text()
            if (result == 'OK') {
                favoriteDrinks.push({
                    idDrink: idDrink,
                    strDrink: strDrink,
                    strDrinkThumb: strDrinkThumb
                })
                $(element).attr("disabled", true)
                $(".bloqueo_pantalla").hide()
            }
        } else {
            alert("There is an error!")
            $(".bloqueo_pantalla").hide()
        }
    } catch (e) {
        console.error(e)
        alert("There is an error!")
        $(".bloqueo_pantalla").hide()
    }
}

async function deleteFavoriteDrink(idDrink) {
    try {
        $(".bloqueo_pantalla").show()
        const response = await fetch(`/cocktail/DeleteFavoriteDrink?idDrink=${idDrink}`, {
            method: 'DELETE',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: { 'Content-Type': 'application/json' },
            redirect: 'follow',
            referrerPolicy: 'no-referrer'
        })
        if (response.ok) {
            const result = await response.text()
            if (result == 'OK') {
                const index = favoriteDrinks.findIndex(d => d.idDrink === idDrink)
                favoriteDrinks.splice(index, 1);
                showFavoriteCocktails()
                $(".bloqueo_pantalla").hide()
            }
        } else {
            alert("There is an error!")
            $(".bloqueo_pantalla").hide()
        }
    } catch (e) {
        console.error(e)
        alert("There is an error!")
        $(".bloqueo_pantalla").hide()
    }
}

function showFavoriteCocktails() {
    if (favoriteDrinks && favoriteDrinks.length > 0) {
        let rows = ''
        for (let i = 0; i < favoriteDrinks.length; i++) {
            let templateCard = `<div class="col-sm mb-4">
                                        <div class="card" style="width: 18rem;">
                                            <img src="${favoriteDrinks[i].strDrinkThumb}" class="card-img-top">
                                            <div class="card-body">
                                                <h5 class="card-title">${favoriteDrinks[i].strDrink}</h5>
                                                <button
                                                    class="btn btn-primary"
                                                    onclick="deleteFavoriteDrink(${favoriteDrinks[i].idDrink})"
                                                >
                                                    Delete
                                                </button>
                                            </div>
                                        </div>
                                    </div>`
            rows += templateCard
        }
        $("#favorite_cocktails_added").html(`<div class="row">${rows}</div>`)
    } else {
        $("#favorite_cocktails_added").html("<h3>No data found</h3>")
    }
}

function controlViewActual() {
    switch (viewActual) {
        case 'SEARCH':
            $("#favorite_cocktails").show()
            $("#search_cocktails").hide()
            showFavoriteCocktails()
            $("#btn_favorite_drinks").text("Search cocktails")
            viewActual = 'FAVORITE'
            break
        case 'FAVORITE':
            $("#favorite_cocktails").hide()
            $("#search_cocktails").show()
            $("#btn_favorite_drinks").text("My favorite cocktails")
            viewActual = 'SEARCH'
            break
    }
}

function controlTypeSearch() {
    const typeSearch = $("input[name='typeSearch']:checked").val()
    switch (typeSearch) {
        case 'BY_NAME':
            $("#txtNameCocktail").show()
            $("#slIngredients").hide()
            break
        case 'BY_INGREDIENT':
            $("#txtNameCocktail").hide()
            $("#slIngredients").show()
            break
    }
}