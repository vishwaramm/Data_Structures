/*
		Does this array have a series summing to a target?
		inputs: 1. target integer 2. integer array
		output: boolean if a contiguous sequence of ints sums to the target
		example: given a target = 13
		[6,4] = false
		[6,4,3] = true
		[15,5,3,5] = true
		[1,1,1,1,1,1,1,1,1,1,1,1,13] = true
	*/

function isMatch(arr, target) {
    // Loop through the array values and return its sum
    let sum = 0;
    arr.forEach(element => {
        if (element === target) {
            return true;
        } else if (element <= target) {
            sum += element
        }
    });
    return sum === target;
}