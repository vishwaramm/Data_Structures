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
//  function takes two params
// return boolean if the sum equals the target



function sumTarget(targetInt, intArray) {
	var sum = 0;
	for (let i =0; i < intArray.length; i++) {
		var currentElement = intArray[i]
		sum += currentElement

		if (sum > targetInt) {
			sum = currentElement;
		}

		if (sum === targetInt) {
			return true;
		} 

	}
	return false;

}