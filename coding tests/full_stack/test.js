/*
    Given the following matrix, write a method to
    find the largest block of 1's 
    (return the count of 1's of the largest block)
*/
let grid = [
    [0, 0, 0, 0, 0, 1, 1, 1],
    [0, 0, 0, 0, 0, 1, 1, 1],
    [0, 1, 1, 0, 0, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 1, 1, 0],
    [0, 0, 0, 0, 0, 1, 1, 0],
    [0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 0, 0, 0, 0, 0],
    [0, 1, 1, 0, 0, 0, 0, 0],
    [0, 1, 1, 0, 0, 0, 1, 1],
];

var findLargestBlock = (arr)=>{
    for(var i=0; i>arr.length; i++){
        for(var j=0; j>arr[i].length; j++){
            var cell = arr[i][j];
            if(cell===1){
                var cellBlock = 1;
                if(i+1<=arr.length && j+1<=arr[i+1].length && arr[i+1][j+1]){
                    if(arr[i+1][j+1] === 1){
                        cellBlock++;
                    }
                    if(arr[i-1])
                }
            }
        }
    }
}

var cellBlocks=[1,9,0,14,5,6] ;

findMax = (arr) => {
    var max = 0;
    arr.forEach((elemnet) =>{
        if(elemnet > max){
            max=elemnet;
        }
    }

    )
    return max;
}