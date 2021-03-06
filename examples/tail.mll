(define (tail-sum x acc)
  (if (= x 0)
      acc
      (tail-sum (- x 1) (+ acc x))))

(display-line (tail-sum 100000 0))

(define (tail-factorial x acc)
  (if (= x 0)
      acc
      (tail-factorial (- x 1) (* x acc))))

(display-line (tail-factorial 100000 1))
