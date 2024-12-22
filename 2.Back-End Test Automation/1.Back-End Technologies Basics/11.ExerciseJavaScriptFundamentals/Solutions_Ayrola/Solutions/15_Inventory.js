function createHeroRegister(input) {
    let heroes = [];

    // Process each input string
    input.forEach(heroData => {
        let [heroName, heroLevel, heroItems] = heroData.split(' / ');

        // Parse the hero level to a number
        heroLevel = Number(heroLevel);

        // Split the items string into an array (if items exist), otherwise set to an empty array
        let items = heroItems ? heroItems.split(', ') : [];

        // Store the hero data in an object and push to the heroes array
        heroes.push({ name: heroName, level: heroLevel, items: items });
    });

    // Sort heroes by level (ascending order)
    heroes.sort((a, b) => a.level - b.level);

    // Print the result in the required format
    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    });
}

// Test case
let input = [
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
];
createHeroRegister(input);